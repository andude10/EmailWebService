#  Web-сервис формирования, отправки и логирования Email сообщений.

POST запрос по url /api/mails/ формата json:

```
{
"subject": "string",
"body": "string",
"recipients": [ "string" ]
}
```

Затем формируется сообщение, отправляется и сохраняется (с результатом отправки и 
с текстом ошибки если нужно) сохраняет сообщение в базу WebService (MS SQL).

По GET запросу выдается список всех email'ов в формате json

## Настройка

В файле конфигурации `appsettings.json` нужно ввести данные настройки 
в следующей секции:

```
"SmtpServerConfiguration": {
"DefaultSenderEmail": "пример@пример.com",
"Host": "smtp.gmail.com",
"Port": 111,
"NetworkCredentialUsername": "имяПользователя",
"NetworkCredentialPassword": "пароль"
}
```

Затем ввести команду dotnet для создания базы данных:

`dotnet ef database update`

После этого приложение готово к запуску.

## Использованные технологии

Приложение написано на C# ASP.NET Core.
Реляционная бд: MS SQL.
Используемая ORM: EntityFramework Core.
Для отправки сообщений используется библиотека FluentEmail.