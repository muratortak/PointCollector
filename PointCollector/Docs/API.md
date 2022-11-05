# PointCollector API
    
- [PointCollector API](#pointcollector-api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)

## Auth

### Register
```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "firstName": "first",
    "lastName": "last",
    "email": "email@email.com",
    "password": "pwd123"
}
```

#### Register Response
```js
200 OK
```
### Login

#### Login Request

#### Login Response
