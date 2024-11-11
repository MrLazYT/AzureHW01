﻿using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Services;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarService _carService;
        private readonly IMapper _mapper;

        public CarsController(CarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        // GET: api/<CarController>
        [HttpGet]
        public IActionResult Get()
        {
            List<CarDto> cars = _carService.GetAll();

            return Ok(cars);
        }

        // GET api/<CarController>/5
        /*[HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            CarDto car = _carService.GetById(id);

            return Ok(car);
        }*/

        // POST api/<CarController>
        [HttpPost]
        public IActionResult Post([FromBody] SwaggerCarDto swaggerCarDto)
        {
            CarDto carDto = _mapper.Map<CarDto>(swaggerCarDto);

            _carService.Add(carDto);

            return Ok();
        }

        // PUT api/<CarController>/5
        /*[HttpPut("{id}")]
        public IActionResult Put([FromBody] SwaggerCarDto swaggerCarDto)
        {
            CarDto carDto = _mapper.Map<CarDto>(swaggerCarDto);

            _carService.Update(carDto);

            return Ok();
        }*/

        // DELETE api/<CarController>/5
        /*[HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            CarDto car = _carService.GetById(id);

            _carService.Delete(car);

            return Ok();
        }*/
    }
}
