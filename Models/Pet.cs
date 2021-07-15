using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public enum PetBreedType
    {

        Shepherd, // 54.2 // 0
        Poodle, // 1
        Beagle, // 2
        Bulldog, // 3
        Terrier, // 4
        Boxer, // 5
        Labrador, // 6
        Retriever // 7

    }
    public enum PetColorType
    {
        Black,
        White,
        Golden,
        Spotted,
        Tricolor

    }
    public class Pet
    {

        [Required]
        public string name { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetColorType color { get; set; }


        public DateTime? checkedInAt { get; set; }

        [Required]
        [ForeignKey("PetOwners")]
        public int petOwnerid { get; set; }

        public int id { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetBreedType breed { get; set; }

        public PetOwner petOwner { get; set; }

        public void checkIn()
        {
            checkedInAt = DateTime.Now;
        }

        public void checkOut()
        {
            checkedInAt = null;
        }
    }
}
