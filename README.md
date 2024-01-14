# Bird Spotter (English version below)
De applicatie dient om vogelmeldingen te beheren.

## Domein
Het domein is relatief eenvoudig, er zijn slechts een paar klassen die we bijhouden in de databank, `Bird` en `Spot`. Je mag tijdens het examen geen visibiliteit van de properties aanpassen. Telkens er iemand een vogel spot, houden we een historiek bij de locatie en andere details.

## Puntenverdeling
De punten staan naast de vragen, indien je solution niet compileert (0/20), code in commentaar wordt niet bekeken.

## Functionaliteiten
Er zijn twee primaire functionaliteiten: het bekijken van de lijst van vogels, en het spotten.

## Packages
Alle packages zitten reeds in de projecten, je dient geen extra packages via NuGet toe te voegen, mogelijks wel te gebruiken of te implementeren.

## Vraag 1: Domein (10 pt)

`Spot.SpottedOn` controleert via een [Ardalis Guard Clause](https://github.com/ardalis/GuardClauses/tree/main) in de setter of de gegeven datum maximaal 1 jaar oud is, en niet in de toekomst ligt. Je houdt hierbij enkel de datum van het `DateTime` object over en verwijdert de tijdscomponent.

In `Bird.SpottedAt` controleer je of een spot met die `Latitude` en `Longitude` voor deze vogel nog niet bestaat. Indien die wel al bestaat, gooi je een `EntityAlreadyExistsException` met de relevante informatie. Indien die nog niet bestaat, voeg je de spot toe aan de lijst van spots. Bird_Should.cs kan je gebruiken om te testen of dit werkt.

## Vraag 2: Testing (15 pt)

Schrijf testen in `Spot_Should.cs` voor de klasse `Spot`:
- constructor met geldige datum
- constructor met datum net onder de acceptabele grens (1 dag verschil)
- constructor met datum net boven de acceptabele grens (1 dag verschil)
- herhaal de testen, maar nu voor de setter
Totaal: 6 testen.

## Vraag 3: Configuratie (10 pt)

Voeg volgende database configuratie toe:
- `Bird.Name` is uniek en heeft maximale lengte 1000 characters
- `Spot` kan niet bestaan zonder een `Bird`
- Wanneer een `Bird` wordt verwijderd, worden zijn `Spot`s ook verwijderd

## Vraag 4: Spotten van een vogel (20 pt)

Je kan op dit moment nog geen vogels spotten. Implementeer de form.
Gebruik een `EditForm` met `FluentValidation`. Gebruik niet de validatie per veld, maar lijst alle validatieproblemen op aan het begin van de form.
Voeg validatie toe:
- `BirdId` moet ingevuld zijn
- `Latitude` en `Longitude` moeten ingevuld zijn
- `SpottedOn` moet ingevuld zijn, mag niet meer dan een jaar geleden zijn, en mag niet in de toekomst liggen.

Wanneer er geen vogels in de database zitten, toon je geen form.

Na het succesvol toevoegen van een spot in de databank, navigeer je naar het overzicht van de vogels.


https://github.com/HOGENT-Web/csharp-examination-2023-starter-1/assets/10981553/ff053aca-da8c-43c1-9672-d6e0be73ea8d


## Vraag 5: Optimalisatie (10 pt)
In de klasse `Services.Birds.BirdService` is er een functie genaamd `GetIndexAsync`. Optimaliseer de bevraging van de database zonder de signatuur aan te passen.
PS: Het gaat hier niet om het pagen van items, noch over caching.

## Vraag 6: Logging middleware (10 pt)
Voeg logging middleware toe zodat per request op de server duidelijk is hoelang deze geduurd heeft.

Voorbeeld output:
```
info: Server.Middleware.ElapsedTimeMiddleware[0]
      Request for /api/bird took: 35ms
```

## Vraag 7: Notificaties (10 pt)
Wanneer een spot wordt toegevoegd, moet er een alert getoond worden: "The BIRD is the WORD!".
Gebruik hiervoor het package [SweetAlert2](https://www.nuget.org/packages/CurrieTechnologies.Razor.SweetAlert2/).


https://github.com/HOGENT-Web/csharp-examination-2023-starter-1/assets/10981553/c08fb835-2675-4e85-abbc-c5061cfe7e41


## Vraag 8: Interop (15 pt)
We zouden graag de locatie van de gebruiker bemachtigen bij het toevoegen van een spot. Op de pagina `Prototypes/CurrentLocation.razor` dien je dit te implementeren. Wanneer er op de knop `Get Location` geklikt wordt, worden de velden `latitude` en `longitude` ingevuld in de voorziene tekstboxen met de locatie van de gebruiker op dat moment. Allicht heb je wat aan de volgende zoektermen: "Blazor Interop" en Geolocation JavaScript. Je mag geen packages toevoegen aan de solution. JavaScript dien je te schrijven in de `Client/wwwroot/index.html`.


https://github.com/HOGENT-Web/csharp-examination-2023-starter-1/assets/10981553/56f1e5d7-e988-4fe7-afa7-ae516a38c4c6


# English version

# Bird Spotter
The application serves to manage bird reports.

## Domain
The domain is relatively simple, there are only a couple of classes we keep in the database, `Bird` and `Spot`. You are not allowed to change the visibility of the properties during the exam. Every time someone spots a bird, we keep a history of its location and other details.

## Points distribution
Points are listed next to the questions if your solution does not compile (0/20), code in comments is not considered.

## Functionalities
There are two primary functionalities: viewing the list of birds, and spotting.

## Packages
All packages are already in the projects, you do not need to add additional packages via NuGet, possibly to use or implement.

## Question 1: Domain (10 pt)

`Spot.SpottedOn` checks in the setter via an [Ardalis Guard Clause](https://github.com/ardalis/GuardClauses/tree/main) that the given date is at most 1 year old, and not in the future. In doing so, you keep only the date of the `DateTime` object and remove the time component.

In `Bird.SpottedAt` you check if a spot with that `Latitude` and `Longitude` for this bird does not already exist. If it already exists, you throw an `EntityAlreadyExistsException` with the relevant information. If it does not yet exist, add the spot to the list of spots.
Bird_Should.cs can be used to test if this works.

## Question 2: Testing (15 pt)

Write tests in `Spot_Should.cs` for the class `Spot`:
- constructor with valid date
- constructor with date just below acceptable limit (1 day difference)
- constructor with date just above the acceptable limit (1 day difference)
- Repeat the tests, but this time for the setter
Total: 6 tests.

## Question 3: Configuration (10 pt)

Add the following database configuration:
- `Bird.Name` is unique and has maximum length 1000 characters
- `Spot` cannot exist without a `Bird`
- When a `Bird` is deleted, its `Spot`s are also deleted

## Question 4: Spotting a bird (20 pt)

You can't spot birds at the moment. Implement the form.
Use an `EditForm` with `FluentValidation`. Do not use per-field validation, but list all validation issues at the beginning of the form.
Add validation:
- `BirdId` must be filled in
- `SpottedOn` must be filled in, must not be more than a year ago, and must not be in the future.

If there are no birds in the database, do not show a form.

After successfully adding a spot to the database, navigate to the bird overview.

https://github.com/HOGENT-Web/csharp-examination-2023-starter-1/assets/10981553/ff053aca-da8c-43c1-9672-d6e0be73ea8d


## Question 5: Optimization (10 pt)
In the `Services.Birds.BirdService` class, there is a function called `GetIndexAsync`. Optimize the database query without changing the signature of the function.
P.S: This is not about paging items, nor about caching.

## Question 6: Logging middleware (10 pt)
Add logging middleware so that for each request on the server, it is clear how long it took.

Example output:
```
info: Server.Middleware.ElapsedTimeMiddleware[0]
      Request for /api/bird took: 35ms
```

## Question 7: Notifications (10 pt)
When a spot is added, an alert should be shown: "The BIRD is the WORD!".
For this, use the package [SweetAlert2](https://www.nuget.org/packages/CurrieTechnologies.Razor.SweetAlert2/).

https://github.com/HOGENT-Web/csharp-examination-2023-starter-1/assets/10981553/c08fb835-2675-4e85-abbc-c5061cfe7e41

## Question 8: Interop (15 pt)
We would like to obtain the user's location when adding a spot. On the page `Prototypes/CurrentLocation.razor`, you need to implement this. When the `Get Location` button is clicked, the fields `latitude` and `longitude` should be filled in the provided text boxes with the user's location at that time. You might find the following search terms useful: "Blazor Interop" and Geolocation JavaScript. You are not allowed to add packages to the solution. JavaScript should be written in the `Client/wwwroot/index.html`.


https://github.com/HOGENT-Web/csharp-examination-2023-starter-1/assets/10981553/56f1e5d7-e988-4fe7-afa7-ae516a38c4c6


