# Webshop

# Förklaringar

- [ ] Valet av camelCase i Models var utifrån att det externa APIet började med liten bokstav

# Frågor


- [x] ~~Kan Admin Ändra/Lägg till vara på två olika sidor eller måste dom vara på samma sida?~~ Kan vara på flera sidor om det behövs
- [ ] Har vi möjlighet att få G eller VG om vi får ordning på nuvarande logik? Eller är vi tvugna att göra om logiken så att ProductManager innehåller alla metoder?
- [ ] Har du tips på var vi kan läsa om persistence? Är det detta vi ska göra: https://www.learnrazorpages.com/razor-pages/cookies

# TODO

- [ ] Göra README läsbar för lärare
- [ ] Räkna ut korrekt pris för GroupBuy i Product klassen
- [x] Gör search till case insensitive - tex ToLower
- [x] **Try-catch** istället för **!= null**
- [ ] Inheritance - ~~kanske Sales product med EndDate som prop och metod? % för sale, metod som räknar ut och en sträng som kan användas för att visa normal pris och sales pris~~ - Fråga Albin om vi behöver mer arv?
- [ ] ~~Söka inom en kategori~~
- [ ] Admin Ändra/Lägg till - Funktion för att ej skapa dubbletter
- [ ] Kan Product.id vara lika med List<Index>?
- [ ] Använd Get/Set - tex så att lagersaldo aldrig kan vara < 0
- [x] Få in metoder i **Manager.x**
- [ ] Göra så att GroupBuy inte går att göra mnauellt - utvalda produkter som görs till en GroupBuy
- [x] Se till så att det bara kan ligga 1 order i orders listan
- [ ] Ändra OrderItem till Product?

# Startsida

- [x] Välkomst-text
- [x] Bild
- [x] Tre **utvalda** produkter

# Shopsida

- [x] Minst tre kategorier
- [x] Fritextsöka
- [x] Klickbara produkter för mer info
- [x] Addera till **varukorg**
- [x] Kort text om produkten, pris och bild
- [x] Lagersaldo (som räknas ner när varan köps)

# Varukorg

## Valda produkter visas i lista

- [x] Ändra antal
- [x] Ta bort
- [x] Pris per produkt
- [x] Summa

## Frakt

- [x] Formulär med namn, adress osv
- [x] Val av frakt, minst två med olika pris

## Betala

- [x] Visa produkter med pris
- [x] Pris med frakt
- [x] Moms
- [x] Betalningsmetod, minst två
- [x] När varan är betald så töms varukorgen

# Admin

- [x] Ändra produkter
- [x] Lägg till nya produkter

# Style
