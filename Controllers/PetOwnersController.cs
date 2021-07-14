using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPetOwners() {
            var petOwners = _context.PetOwners.ToList();
            return  petOwners;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PetOwner petOwner)
        {
            _context.Add(petOwner);
            _context.SaveChanges();
            Console.WriteLine(CreatedAtAction(nameof(GetPetOwners), petOwner));
            return CreatedAtAction(nameof(GetPetOwners), petOwner);
        }
        //hey
        [HttpDelete("{id}")]

        public IActionResult DeletePetOwner(int id)
        {
            PetOwner ownerToDelete = _context.PetOwners.Find(id);
            if(ownerToDelete == null) return NotFound();

            _context.PetOwners.Remove(ownerToDelete);
            _context.SaveChanges();

            return NoContent();

        }
    }
}
