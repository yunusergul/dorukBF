# DorukBF

This project allows you to run both backend and frontend components using Docker Compose.

## Getting Started

To start your project, follow these steps:

1. Open your terminal and navigate to the project directory.
2. Run the following command:

   ```bash
   docker compose up

You can access the project at [http://localhost:8080](http://localhost:8080). The port can be changed in the .env file using the NGINX_PORT variable. After modifying the port, make sure to run the following command to rebuild and restart the containers:

   ```bash
   docker compose up --build
