# Webshop

Hej! Här är vår webshop - **MEGABÖRS**. Vi bestämde oss för att implementera det externa APIet först för att utnyttja ett redan definierat produktutbud. För att använda oss av Arv så skapade vi en klass för Group sale där köparen kan köpa x antal produkter för ett nedsatt pris.

När vi adderade cookies för att spara innehållet i varukorgen så märkte vi att cookiens maximala filstorlek stoppade oss från att spara mer än ~6 produkter. Vi tänkte om och la till två knappar för Svenska och English på startsidan. Den ändrar bara Välkoms-texten men konceptet hade även kunnat användas till andra funktioner.

# Förklaringar

- Valet av camelCase i Models var utifrån att det externa APIet började med liten bokstav

# Presentation 18/11 @Teams

<details>
  <summary>Click to expand!</summary>

- API
- För att få produkter
- Färdigdefinierad klass
- Main körs en gång
  - APICall - hämtar grundutudet
  - Threechosen - 3 första i listan till chosen=true
  - ~~Readcookie - bool sätts till true vid start för att lägga in cart-cookie~~
  - Stopwatch - problematik med kompilering/debug-tid
- Home
  - Språk-cookie - cookie begränsad till 4kb - rimligt att spara språkinställning
  - Utvalda produkter - från Threechosen
- Products
  - Mer info + lagersaldo - random stock
  - Kategorier - OnPost sorterar listan enligt kategorinamn
  - Söka - använder contains med linq söker i produkternas properties
  - Purchase - Skickar item.Id till Cart lista
- Cart
  - Lägg in en produkt
  - Cartcookie - begränsad till 4kb och funkar dåligt
- Cart/Checkout
  - Enums - val av frakt, fördefinierade värden
  - Kräver att fälten är ifyllda - modelstate checkar om den får vad den vill ha, annars meddelande till skärm
  - Finalize - rensar och ändrar stock, printar meddelande.
- Admin
  - Rensar cart - Blir fel i cart om produkten ändras
  - Add
  - Change
  - Group sale - arv som skapar flera av grund-item till en sammanslagen produkt. inte optimalt pga produkterna från api:t fanns bara som product. någon annan som gjort som oss?
  </details>

# TODO (or forget)

<details>
  <summary>Click to expand!</summary>

- [ ] Sidan kraschar om det saknas text i alla fält på Add product. Lägg in fördefinierade kategorier eller kräva alla fält ifyllda
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

</details>

# Beståndsdelar och speckrav

<details>
   <summary>Click to expand!</summary>
  
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

</details>
