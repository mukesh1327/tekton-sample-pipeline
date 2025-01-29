# Stage 2: Runtime stage using OpenJDK runtime
FROM registry.access.redhat.com/ubi9/openjdk-17

WORKDIR /app

# # Copy the jar file from the build stage
COPY ./target/todo-app.jar todo-app.jar

# Expose the port the application will run on
EXPOSE 9001

# Entry point for the application
ENTRYPOINT ["java", "-jar", "todo-app.jar"]