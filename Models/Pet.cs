using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public enum PetBreedType {

        Shepherd, // 54.2 // 0
        Poodle, // 1
        Beagle, // 2
        Cat,
        Bulldog, // 3
        Terrier, // 4
        Boxer, // 5
        Labrador, // 6
        Retriever // 7

    }
    public enum PetColorType {}
    public class Pet {
        public string name {get; set;}
        public PetColorType color {get; set;}

        
        public DateTime? checkedInAt {get; set;}
        
        [ForeignKey("PetOwners")]

        public int petOwnerid {get; set;}  

        public int id {get; set;}  

        public PetBreedType breed {get; set;}

        public PetOwner petOwner {get; set;}

        // public void checkIn()
        // {
        //     checkedInAt 
        // }

        public void checkOut() {
            checkedInAt = null;
        }
    }
}
