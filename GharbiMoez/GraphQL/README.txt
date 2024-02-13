# TravelBookingGraphQl

Grahql user information 
query {
   userInformationById(userId: 1){
    username,
    email,
     busPhone,
     
      
        prov,
         postal,
         country
    city
  }
}
{
  "data": {
    "userInformationById": {
      "username": "johndoe",
      "email": "123",
      "busPhone": null,
      "prov": "",
      "postal": "123",
      "country": null,
      "city": "123"
    }
  }
}




Graphql Travel with list <product(hotel,car)> ,list <activite> ,Aircraft 

query {
  allTravelByCustomerId(customerId: 1){
    travelName,
    travelId,
    travelDate,activities{
      urlImageAct
    },products{
      prodName
       
    }
    ttname,
    activities{
      urlImageAct
    }
     companyName,
      flightNumber,
      seatNumber
  }
}
{
  "data": {
    "allTravelByCustomerId": [
      {
        "travelName": "Marrakech_sejour",
        "travelId": 1,
        "travelDate": "2024-01-10T00:00:00",
        "activities": [
          {
            "urlImageAct": "activite 1"
          },
          {
            "urlImageAct": "activite 1"
          },
          {
            "urlImageAct": "activite 1"
          }
        ],
        "products": [
          {
            "prodName": "Golden Tulip"
          },
          {
            "prodName": "BMW"
          },
          {
            "prodName": "Movenpick"
          }
        ],
        "ttname": "Trip Business",
        "companyName": "TUNISAIR",
        "flightNumber": "ABC123",
        "seatNumber": "12A"
      },
      {
        "travelName": "Tunis_Séjour",
        "travelId": 2,
        "travelDate": "2024-01-10T00:00:00",
        "activities": [],
        "products": [],
        "ttname": "Trip Business",
        "companyName": "AIRFRANCE",
        "flightNumber": "ABC123",
        "seatNumber": "12A"
      },
      {
        "travelName": "Cairo_Sejour",
        "travelId": 4,
        "travelDate": "2024-02-10T00:00:00",
        "activities": [],
        "products": [],
        "ttname": "Trip Business",
        "companyName": "TUNISAIR",
        "flightNumber": "ABC123",
        "seatNumber": "12A"
      },
      {
        "travelName": "Manhatan_Sejour",
        "travelId": 5,
        "travelDate": "2024-02-10T00:00:00",
        "activities": [],
        "products": [],
        "ttname": "Trip Business",
        "companyName": "TUNISAIR",
        "flightNumber": "ABC123",
        "seatNumber": "12A"
      }
    ]
  }
}






Graphql liste of product liee a un travel by id 

query {
 allProductsByTravelId(travelId: 1){
    prodName,
    prodDescription,
     
     
  }
}
{
  "data": {
    "allProductsByTravelId": [
      {
        "prodName": "Golden Tulip",
        "prodDescription": "Hotel Description"
      },
      {
        "prodName": "Movenpick",
        "prodDescription": "Hotel Description"
      },
      {
        "prodName": "BMW",
        "prodDescription": "Car Description"
      }
    ]
  }
}




Graphql logn 

query {
 login(username: "string",password: "string"){
    username,
    userId,
   
   
  }
}
{
  "data": {
    "login": {
      "username": "string",
      "userId": 6
    }
  }
}

