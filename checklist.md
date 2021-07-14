okay guys

hi owen

hey

[] build backend for pet hotel
    [x] make model for pet owners
    [] make model for pets
    [x] Add petowners to ApplicationContext
    [] Add pets to ApplicationContext
    [] Migrate db for both pets & petowners tables
        [x] petowners
            [x] id
            [x] name
            [x] emailAddress
                [] ***(NEEDS TO BE VALIDATED)***
            [] petCount
        [] pets
            [] name
            [] color
            [] checkedInAt
            [] petOwnerId
            [] Id
            [] breed
            [] petOwner (link entire petOwner object)
    [] Create controllers
        [] PetOwners
            [x] Finish GET route
            [x] Post (add new pet owner)
            [] Put 
            [] Delete (remove pet owner)
        [] Pets
            [] Finish GET route
            [] Post (add new pet)
            [] Put (check in/out pet)
            [] Delete (remove pet)
    [] Test controllers
        [] Postman
        [] Jest (front-end)
    [] Make sure it works 😎
