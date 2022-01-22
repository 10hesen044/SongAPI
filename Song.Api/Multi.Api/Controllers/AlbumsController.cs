using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multi.Api.DTOs.AlbumDtos;
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
    public class AlbumsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AlbumsController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(AlbumPostDto postDto)
        {
            Album album = new Album
            {
                Name = postDto.Name
            };

            _context.Albums.Add(album);
            _context.SaveChanges();

            //return StatusCode(201,new {album.Id});
            return StatusCode(201, new { Id = album.Id });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Album album = _context.Albums.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (album == null) return NotFound();

            AlbumGetDto albumGetDto = _mapper.Map<AlbumGetDto>(album);

            return Ok(albumGetDto);
        }

        private AlbumGetDto _mapToAlbumGetDto(Album album)
        {
            AlbumGetDto albumGetDto = new AlbumGetDto
            {
                Id = album.Id,
                Name = album.Name,
                CreatedAt = album.CreatedAt,
                ModifiedAt = album.ModifiedAt
            };

            return albumGetDto;
        }

        [HttpGet("")]
        public IActionResult GetAll(int page = 1)
        {
            var albums = _context.Albums.Include(x => x.Musics).Where(x => !x.IsDeleted);

            AlbumListDto AlbumListDto = new AlbumListDto
            {
                Items = new List<AlbumListItemDto>(),
                TotalPage = (int)Math.Ceiling(albums.Count() / 4d)
            };

            albums = albums.Skip((page - 1) * 4).Take(4);

            AlbumListDto.Items = _mapper.Map<List<AlbumListItemDto>>(albums.ToList());

            return Ok(AlbumListDto);
        }

        public IActionResult Update(AlbumPostDto dto, int id)
        {
            Album existAlbum = _context.Albums.FirstOrDefault(x => x.Id == id);

            if (existAlbum == null) return NotFound();

            existAlbum.Name = dto.Name;

            _context.SaveChanges();

            return NoContent();
        }

        /////////////////JWT///////////////////////////

        [HttpPut("{id}")]
        public IActionResult Edit(AlbumPostDto albumDto,int id)
        {
            Album album = _context.Albums.FirstOrDefault(x => x.Id == id && !x.IsDeleted);

            if (album == null) return NotFound();

            album.Name = albumDto.Name;
            album.ModifiedAt = DateTime.UtcNow.AddHours(4);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
