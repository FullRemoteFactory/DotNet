# TravelBookingGraphQl

# TravelBookingGraphQl

# Grahql user information 
#query {
  userInformationById(userId: 1){
    username,
    email,
    busPhone,   
    prov,
    postal,
    country,
    city
  }
}
{
 # "data": {
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

![Capture d'écran 2024-02-13 183927](https://github.com/gharbyMoez/TravelBookingGraphQl/assets/73045903/2df17c11-cf65-4d7d-9021-f917c5ebf5e8)


Graphql Travel with list <product(hotel,car)> ,list <activite> ,Aircraft 

#query {
  #allTravelByCustomerId(customerId: 1)
  {
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
 # "data": {
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
![Capture d'écran 2024-02-13 184332](https://github.com/gharbyMoez/TravelBookingGraphQl/assets/73045903/d158cbb3-e5d8-4afa-89d3-9daeb6591256)
![Capture d'écran 2024-02-13 184429](https://github.com/gharbyMoez/TravelBookingGraphQl/assets/73045903/3a41e147-5c38-4d06-a317-3fcc32da2190)
![Capture d'écran 2024-02-13 184948](https://github.com/gharbyMoez/TravelBookingGraphQl/assets/73045903/d0a9ffba-29c4-4131-9aa8-36768edaec72)





#Graphql liste of product liee a un travel by id 

#query {
 allProductsByTravelId(travelId: 1){
    prodName,
    prodDescription,   
   }
}
#{
  "data": {
   "allProductsByTravelId":  [
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
![Capture d'écran 2024-02-13 185432](https://github.com/gharbyMoez/TravelBookingGraphQl/assets/73045903/724c49ec-dbd1-4588-a647-cf85fa481d64)




Graphql logn 

#query {
 #login(username: "string",password: "string"){
    username,
    userId,     
  }
}
#{
 # "data": {
    #"login": {
      "username": "string",
      "userId": 6
    }
  }
}
![Capture d'écran 2024-02-13 190018](https://github.com/gharbyMoez/TravelBookingGraphQl/assets/73045903/47080be1-4d1c-49f3-b571-40069dc1924d)

