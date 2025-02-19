package com.zagaopc.quarkustodo.exception;

import jakarta.ws.rs.core.Response;
import jakarta.ws.rs.ext.ExceptionMapper;
import jakarta.ws.rs.ext.Provider;

@Provider
public class TasksExceptionMapper implements ExceptionMapper<TasksExceptions> {

    @Override
    public Response toResponse(TasksExceptions exception) {
        
        ErrorResponse errorResponse = (ErrorResponse) exception.getResponse().getEntity();
        String errorMessage = errorResponse.getMessage();

        return Response.status(exception.getResponse().getStatus())
                       .entity(errorMessage)
                       .build();
    }
}
