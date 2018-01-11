# RESTFulExample
## Тестовое задание: Реализовать сервис корзины.
### Тестовое задание следующее:
 
Реализовать сервис корзины.
Требования: RESTFul API на C#, используя Entity Framework, Code First, Fluent API, MS SQL Server, MongoDB
(!)MongoDB используется только для логирования Exception.
 
1. В корзину можно добавить одну и более услуг
2. Из корзины можно удалить одну услугу или все сразу
3. Типы услуг: авиабилет, ж/д билет, отель
 
* Должна быть возможность в любой момент добавить новый тип услуг для добавления в корзину.
 
### Модели услуг
Air - {
    "Id": string,
    "Provider": string,
    "DepartureDate": datetime,
    "ArrivalDate": datetime,
    "DepartureAirport": string,
    "ArrivalAirport": string,
    "Traveller": Employee
}
 
Hotel - {
    "Id": string,
    "Provider": string,
    "Checkin": datetime,
    "Checkout": datetime,
    "Name": string,
    "Traveller": Employee
}
 
Train - {
    "Id": string,
    "Provider": string,
    "DepartureDate": datetime,
    "ArrivalDate": datetime,
    "DepartureStation": string,
    "ArrivalStation": string,
    "TrainNumber": string,
    "Traveller": Employee
}
 
Employee - {
    "Id": int,
    "FirstName": string,
    "LastName": string,
}
 
Модель для логирования:
Log - {
    "event_date": datetime,
    "exception": string,
    "method_name": string
}
 
Модель корзины на усмотрение, но она так же должна быть SQL
