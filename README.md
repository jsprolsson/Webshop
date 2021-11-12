# Webshop

# Frågor


- [x] ~~Kan Admin Ändra/Lägg till vara på två olika sidor eller måste dom vara på samma sida?~~ Kan vara på flera sidor om det behövs
- [ ] Har vi möjlighet att få G eller VG om vi får ordning på nuvarande logik? Eller är vi tvugna att göra om logiken så att ProductManager innehåller alla metoder?
- [ ] Har du tips på var vi kan läsa om persistence? Är det detta vi ska göra: https://www.learnrazorpages.com/razor-pages/cookies

# TODO

- [ ] Gör search till case insensitive - tex ToLower
- [ ] **Try-catch** istället för **!= null**
- [ ] Inheritance - ~~kanske Sales product med EndDate som prop och metod? % för sale, metod som räknar ut och en sträng som kan användas för att visa normal pris och sales pris~~ - Fråga Albin om vi behöver mer arv?
- [ ] Söka inom en kategori
- [ ] Admin Ändra/Lägg till - Funktion för att ej skapa dubbletter
- [ ] Använd Get/Set - tex så att lagersaldo aldrig kan vara < 0
- [ ] Få in metoder i **Manager.x**
- [ ] Kan Product.id vara lika med List<Index>?
- [ ] Göra så att GroupBuy inte går att göra mnauellt - utvalda produkter som görs till en GroupBuy
- [ ] Se till så att det bara kan ligga 1 order i orders listan


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
- [ ] Lagersaldo (som räknas ner när varan köps)

# Varukorg

## Valda produkter visas i lista

- [x] Ändra antal
- [x] Ta bort
- [ ] Pris per produkt
- [x] Summa

## Frakt

- [ ] Formulär med namn, adress osv
- [ ] Val av frakt, minst två med olika pris

## Betala

- [ ] Visa produkter med pris
- [ ] Pris med frakt
- [x] Moms
- [ ] Betalningsmetod, minst två
- [ ] När varan är betald så töms varukorgen

# Admin

- [x] Ändra produkter
- [x] Lägg till nya produkter

# Style

