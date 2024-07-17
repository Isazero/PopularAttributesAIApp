# Category Attribute Application

## Requirements

- .NET 8.0 SDK
- ChatGptNet API key

## Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/Isazero/PopularAttributesAIApp.git
   cd PopularAttributesAIApp
2. Add ChatGptNet API key to the configuration.
3. Run the application: 
    ```bash
   dotnet run

## Usage
Send a POST request to the endpoint /Category with the following JSON structure:
```json
    [
        {
            "categoryName": "TVs",
            "subCategories": [
                {
                    "categoryId": 80,
                    "categoryName": "TVs"
                },
            ]
        },
    ]
```
The response will contain the most popular attributes for each subcategory.
## Example
Request:
```json
[
  {
    "categoryName": "TVs",
    "subCategories": [
      {
        "categoryId": 80,
        "categoryName": "TVs"
      }
    ]
  }
]

```

Response:

```json
[
    {
        "categoryId": 80,
        "attributes": ["attribute1", "attribute2", "attribute3"]
    }
]

```

