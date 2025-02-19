package com.zagaopc.quarkustodo.exception;

import jakarta.ws.rs.WebApplicationException;
import jakarta.ws.rs.core.Response;

public class TasksExceptions extends WebApplicationException {

    public TasksExceptions(String message, Response.Status status, Throwable cause) {
        super(Response.status(status).entity(new ErrorResponse(message)).build());
    }

}

