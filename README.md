# MarketPlace
RESTfull API для онлайн-магазина, логическая модель БД представлена ниже.

![Диаграмма без названия drawio (9)](https://github.com/Max1Mcg/MarketPlace/assets/80580481/5f022427-e9ce-4502-afc2-e22ba3d2c170)

<br>**Кратное описание</br>
<br>**1)Использовалась postgresql и EF. Был использован подход Batabase first, затем и в дальнейшем с помощью сгенерированных моделей использовался Code first.</br>
<br>**2)Паттерн репозиторий использован для отделения слоя бизнес-логики от слоя, взаимодействующего с БД. Также был создан базовый репозиторий, реализующий основные операции CRUD.</br>
<br>**3)Бизнес-логика и валидации расписана в сервисах.</br>
<br>**4)Для получения и предоставления данных используются дтошки, а также AutoMapper для удобного маппинга между ними.</br>
<br>**5)Все операции выполняются по средстам http запросов, контроллеры - их обработчики. Маршрутизация была реализована на основе атрибутов.</br>
