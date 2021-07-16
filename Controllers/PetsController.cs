using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetPets() {
            // return new List<Pet>();
            return _context.Pets
            .Include(pet => pet.petOwner)
            .OrderBy(pet => pet.id).ToList();

        }

        [HttpPost]

        public IActionResult Post([FromBody] Pet pet){

            PetOwner owner = _context.PetOwners
                .SingleOrDefault(m => m.id == pet.petOwnerid);

            if (owner == null) // might just be security, in case owner doesn't exist?
            {
                ModelState.AddModelError("petOwnerId", "Invalid Pet Owner ID");
                return ValidationProblem(ModelState);
            }



            _context.Add(pet);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPets), pet);
        }
        

        [HttpDelete("{id}")]

        public IActionResult DeletePet(int id)
        {
            Pet petToDelete = _context.Pets.Find(id);
            if (petToDelete == null) return NotFound();

            _context.Pets.Remove(petToDelete);
            _context.SaveChanges();
            return NoContent();
        }
        

    [HttpPut("{id}/checkin")]

    public IActionResult CheckIn(int id)
    {
        Pet petToCheckIn = _context.Pets.Find(id);
        if (petToCheckIn == null) return NotFound();

        petToCheckIn.checkIn();
        _context.Update(petToCheckIn);
        _context.SaveChanges();

        return Ok(petToCheckIn);
    }

    [HttpPut("{id}/checkout")]

    public IActionResult CheckOut(int id)
    {
        Pet petToCheckOut = _context.Pets.Find(id);
        if (petToCheckOut == null) return NotFound();

        petToCheckOut.checkOut();
        _context.Update(petToCheckOut);
        _context.SaveChanges();

        return Ok(petToCheckOut);
    }

        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }
    }
}
