package com.zagaopc.quarkustodo;

import io.quarkus.runtime.Quarkus;
import io.quarkus.runtime.annotations.QuarkusMain;

@QuarkusMain
public class QuarkusTodoApplication {
    public static void main(String... args) {
        System.out.println("Starting Quarkus application...");

        Quarkus.run(args);

        System.out.println("Quarkus application has stopped.");
    }
}
