# ASP.NET Api project

## Передается модель данных о книге в библиотеке:
- Первичный ключ: Guid Id 
- Название книги: string Title 
- Описание: string Description 
- Автор: string Author 
- Дата публикации книги: DateTime PublishedDate 
- Жанр: string Genre 
- Занята или нет книга в библиотеке: bool TakenStatus
- Физическое состояние книги (0 - плохое, 1 - хорошее): bool Condition

## Запросы: GET, POST, POST{ID}, GET{ID}
### Db: SQLITE
