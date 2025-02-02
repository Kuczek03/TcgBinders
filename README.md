# Aplikacja do Zarządzania Kartami Kolekcjonerskimi

## 📋 Opis projektu
Aplikacja służy do zarządzania kolekcją kart kolekcjonerskich. Umożliwia użytkownikom organizowanie swoich zbiorów, przeglądanie dostępnych kart oraz śledzenie ich stanu. Posiada również panel administracyjny do zarządzania użytkownikami i logami aktywności.

## 🚀 Funkcjonalności
- ✅ Rejestracja i logowanie użytkowników
- 📦 Zarządzanie kolekcją kart (dodawanie, edytowanie, usuwanie)
- 🔍 Przeglądanie i wyszukiwanie kart
- 🗂️ Zarządzanie grami, setami i kartami
- 👤 Panel administracyjny z wglądem w logi użytkowników
- 🗒️ Historia aktywności użytkownika (logowanie, modyfikacje kolekcji)

## 🛠️ Technologie
- **Backend:** ASP.NET Core
- **Baza danych:** PostgreSQL
- **Frontend:** HTML, CSS, JavaScript
- **IDE:** JetBrains Rider
- **Kontrola wersji:** Git
- **Testowanie API:** Postman
- 
## 📦 Instrukcja instalacji i uruchomienia

### Wymagania wstępne
- Zainstalowany .NET 8 SDK (wersja zgodna z ASP.NET Core)
- Zainstalowany PostgreSQL
- Git do klonowania repozytorium

### Kroki instalacji
1. **Sklonuj repozytorium:**  
   `git clone https://github.com/twoje-repozytorium.git`

2. **Przejdź do folderu projektu:**  
   `cd twoje-repozytorium`

3. **Skonfiguruj połączenie z bazą danych:**  
   W pliku `appsettings.json` ustaw poprawne dane dostępowe do bazy PostgreSQL.

4. **Wykonaj migracje bazy danych:**  
   `dotnet ef database update`

5. **Uruchom aplikację:**  
   `dotnet run`

6. **Otwórz w przeglądarce:**  
   Aplikacja powinna być dostępna pod adresem `http://localhost:5000` ewentualnie `http://localhost:5274`
   
## 📡 Endpointy API
### 🎮 Zarządzanie grami
- `GET /CardGame` - Lista wszystkich gier (dostępne dla wszystkich)
- `POST /CardGame/Create` - Dodanie nowej gry (administrator)

### 📑 Zarządzanie kartami
- `GET /Card` - Lista wszystkich kart (dostępne dla wszystkich)
- `POST /Card/Create` - Dodanie nowej karty (administrator)
- `POST /Binder/AddCardToCollection/{id}` - Dodanie karty do kolekcji (zalogowany użytkownik)
- `DELETE /Binder/RemoveCardFromCollection/{id}` - Usunięcie karty z kolekcji (zalogowany użytkownik)

### 👥 Zarządzanie użytkownikami
- `GET /Account/Register` - Formularz rejestracji
- `POST /Account/Login` - Logowanie użytkownika
- `GET /Admin/UserLogs` - Przeglądanie logów aktywności (administrator)

## 🗃️ Procedury w bazie danych
- **`LogUserAction(_UserId INT, _Message TEXT)`** - Rejestracja działań użytkownika
- **`AddCardToBinder(_UserId INT, _CardId INT)`** - Dodanie karty do kolekcji
- **`RemoveCardFromCollection(_UserId INT, _CardId INT)`** - Usunięcie karty z kolekcji
- **`SearchCardByName(_CardName TEXT)`** - Wyszukiwanie kart po nazwie

## ⚠️ Trudności napotkane w projekcie
- Integracja z Microsoft Identity oraz migracje do PostgreSQL
- Problemy z mapowaniem typów danych (BOOL vs INT)
- Wyzwania związane z optymalizacją wydajności przy dużej liczbie użytkowników

## 💡 Wnioski
Projekt umożliwił zdobycie praktycznego doświadczenia z ASP.NET Core, PostgreSQL i zarządzaniem procedurami składowanymi. Zaimplementowano skuteczny system uwierzytelniania oraz zarządzania uprawnieniami użytkowników. Planowane dalsze usprawnienia to:

- Integracja z zewnętrznymi API
- Rozbudowa interfejsu użytkownika
- Dalsza optymalizacja wydajności

---

📬 **Kontakt:** [Twoje dane kontaktowe tutaj]

🌟 Dziękujemy za zainteresowanie projektem!
