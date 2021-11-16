# Webshop

Hej! Här är vår webshop - **MEGABÖRS**. Vi bestämde oss för att implementera det externa APIet först för att utnyttja ett redan definierat produktutbud. För att använda oss av Arv så skapade vi en klass för Group buy där köparen kan köpa x antal produkter för ett nedsatt pris.

När vi adderade cookies för att spara innehållet i varukorgen så märkte vi att cookiens maximala filstorlek stoppade oss från att spara mer än ~6 produkter. Vi tänkte om och la till två knappar för Svenska och English på startsidan. Den ändrar bara Välkoms-texten.

# Förklaringar

- Valet av camelCase i Models var utifrån att det externa APIet började med liten bokstav

# TODO

- [ ] ~~Söka inom en kategori~~
- [ ] Admin Ändra/Lägg till - Funktion för att ej skapa dubbletter
- [ ] Kanske Product.id vara lika med List<Index>?
- [ ] Använd Get/Set - tex så att lagersaldo aldrig kan vara < 0
- [x] Räkna ut korrekt pris för GroupBuy i Product klassen
- [x] Gör search till case insensitive - tex ToLower
- [x] **Try-catch** istället för **!= null**
- [x] Inheritance - kanske Sales product med EndDate som prop och metod? % för sale, metod som räknar ut och en sträng som kan användas för att visa normal pris och sales pris
- [x] Få in metoder i **Manager.x**
- [x] Göra så att GroupBuy inte går att göra mnauellt - utvalda produkter som görs till en GroupBuy
- [x] Se till så att det bara kan ligga 1 order i orders listan
- [x] Ändra OrderItem till Product?

# Beståndsdelar

## Startsida

- [x] Välkomst-text
- [x] Bild
- [x] Tre **utvalda** produkter

## Shopsida

- [x] Minst tre kategorier
- [x] Fritextsöka
- [x] Klickbara produkter för mer info
- [x] Addera till **varukorg**
- [x] Kort text om produkten, pris och bild
- [x] Lagersaldo (som räknas ner när varan köps)

## Varukorg

### Valda produkter visas i lista

- [x] Ändra antal
- [x] Ta bort
- [x] Pris per produkt
- [x] Summa

### Frakt

- [x] Formulär med namn, adress osv
- [x] Val av frakt, minst två med olika pris

### Betala

- [x] Visa produkter med pris
- [x] Pris med frakt
- [x] Moms
- [x] Betalningsmetod, minst två
- [x] När varan är betald så töms varukorgen

## Admin

- [x] Ändra produkter
- [x] Lägg till nya produkter
