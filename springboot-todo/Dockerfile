# Stage 1: Build stage using Red Hat JDK (for development)
FROM registry.redhat.io/amq-streams/maven-builder-rhel9:2.8.0-3 AS build
WORKDIR /app

# Set up environment variables if needed
ENV JAVA_HOME=/usr/lib/jvm/java-17-openjdk
ENV PATH=$JAVA_HOME/bin:$PATH

# Ensure permissions are correct
RUN mkdir -p /app/target && chmod -R 777 /app

# Copy the Spring Boot project files
COPY pom.xml .
COPY src ./src

# Resolve dependencies first to avoid issues later
RUN mvn dependency:resolve

RUN mvn clean package -DskipTests

# Stage 2: Runtime stage using OpenJDK runtime
FROM registry.access.redhat.com/ubi9/openjdk-17 AS runtime
WORKDIR /app

# # Copy the jar file from the build stage
COPY --from=build /app/target/todo-app.jar todo-app.jar

# Expose the port the application will run on
EXPOSE 9001

# Entry point for the application
ENTRYPOINT ["java", "-jar", "todo-app.jar"]