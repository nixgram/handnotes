# Handnotes known as Hashnotes in heroku !

Simple Post getter and setter live API project using asp.net core with Swagger ![](https://github.com/sefatanam/handnotes/actions/workflows/dotnet.yml/badge.svg)

Have a look: https://hashnotes.herokuapp.com

### Usage
1. Clone the repository
2. Open in Visual Studio 2019
3. Make sure you have ASP.net Core 3.0 installed
4. Build Application
5. Feel Free to RUN 💥

### How to use API 
- https://hashnotes.herokuapp.com/api/v1/posts


### Features
- can use for a CRUDS operation

### Class Shape
```csharp
  public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
    }
  ```
### JSON View
```javascript
[
  {
    "id": "63d0f320-e36b-459f-8468-a545f600e275",
    "title": "Ki Obostha ??",
    "descriptions": "Valo"
  }
]
```
