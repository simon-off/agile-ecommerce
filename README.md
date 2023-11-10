# **MANERO** Ⓜ️

A made up e-commerce site made with [ASP.NET](https://asp.net/) and [React](https://react.dev/)

## Description

This project is part of the course submission at the .NET developer program at [ECUtbildning](https://ecutbildning.se/).

It was a group project aiming to practice agile working methodologies and project management. We worked together in a team of eight and used Jira as our project management system.

### Backend 🧛

Our API was built using ASP.NET Core. We used Entity Framework Core as our database ORM with SQLite. Tests for the API were written using xUnit.

### Frontend 🌞

The frontend was built using React and SCSS. Since we used Vite as our dev server we also chose to use vitest for testing the frontend.

---

## Running the app locally 🏃

**_Before you begin_**, make sure you have the latest version of the [.NET sdk](https://dotnet.microsoft.com/en-us/download/dotnet) installed as well as the [Entity Framework Core .NET CLI Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet). This is needed to create your local database file.

1. Clone the repository to your local machine
2. Navigate to the project directory
3. Create and populate a local SQLite database file by running:

```sh
$ cd backend
$ dotnet ef database update
```

4. Start the .NET API by running:

```sh
$ dotnet run --project WebApi
```

5. Open a new terminal in the project directory
6. Start the React App by running:

```sh
$ cd frontend
$ npm install
$ npm run dev
```

---

## Authors 📜

- [Viggo Valfridsson](https://github.com/ViggoValfridsson/)
- [Natanael Augustin](https://github.com/NatanaelAugustin/)
- [Simon Bäckström](https://github.com/simon-off/)
- [Andreas Kostet](https://github.com/andreaskostet/)
- [Leon Lagergren](https://github.com/Lwonla/)
- [Erik Östemark](https://github.com/fenetreVRT/)
- [Mohammad Nabi](https://github.com/MohammadNabi01/)
