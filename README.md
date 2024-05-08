## Налаштування та запуск backend через Docker

### Попередні вимоги

Переконайтеся, що у вас встановлені наступні програми:

- Docker: [Офіційний сайт Docker](https://www.docker.com/get-started)

### Інструкції

1. Клонуйте репозиторій на свій локальний комп'ютер:

   ```bash
   git clone https://github.com/yourusername/taskboard.git
   ```

2. Перейдіть до каталогу з проектом:

   ```bash
   cd .../TaskBoard
   ```

3. Запустіть проект за допомогою Docker Compose:

   ```bash
   docker-compose up --build
   ```

4. Api буде доступне за адресом

   ```http
   http://localhost:8088
   ```

## Налаштування та запуск frontend

1. Перейдіть до каталогу з проектом:

   ```bash
   cd .../TaskBoard/TaskBoard.UI
   ```
   
2. Встановіть npm:

   ```bash
   npm install
   ```

3. Перейдіть за портом де прослуховується проект:

   ```bash
   http://localhost:4200
   ```
