using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multi.Api.DTOs.MusicDtos;
using Multi.Core.Entities;
using Multi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public MusicsController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(MusicPostDto postDto)
        {
            Music music = new Music
            {
                Name = postDto.Name
            };

            _context.Musics.Add(music);
            _context.SaveChanges();

            //return StatusCode(201,new {music.Id});
            return StatusCode(201, new { Id = music.Id });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Music music = _context.Musics.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (music == null) return NotFound();

            MusicGetDto musicGetDto = _mapper.Map<MusicGetDto>(music);

            return Ok(musicGetDto);
        }

        private MusicGetDto _mapToMusicGetDto(Music music)
        {
            MusicGetDto musicGetDto = new MusicGetDto
            {
                Id = music.Id,
                Name = music.Name,
                CreatedAt = music.CreatedAt,
                ModifiedAt = music.ModifiedAt
            };

            return musicGetDto;
        }

        [HttpGet("")]
        public IActionResult GetAll(int page = 1)
        {
            var musics = _context.Musics.Include(x => x.Albums).Where(x => !x.IsDeleted);

            MusicListDto musicListDto = new MusicListDto
            {
                Items = new List<MusicListItemDto>(),
                TotalPage = (int)Math.Ceiling(musics.Count() / 4d)
            };

            musics = musics.Skip((page - 1) * 4).Take(4);

            musicListDto.Items = _mapper.Map<List<MusicListItemDto>>(musics.ToList());

            return Ok(musicListDto);
        }

        public IActionResult Update(MusicPostDto dto, int id)
        {
            Music existMusic = _context.Musics.FirstOrDefault(x => x.Id == id);

            if (existMusic == null) return NotFound();

            existMusic.Name = dto.Name;

            _context.SaveChanges();

            return NoContent();
        }
    }
}
