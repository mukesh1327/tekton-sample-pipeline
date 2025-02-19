package com.vpslabs.springboottodo.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api/images")
public class ImageController {

    private static final String IMAGE_URL = "/images/";

    @GetMapping("/{imageName}")
    public String getImageHtml(@PathVariable String imageName) {
        String imagePath = IMAGE_URL + imageName;
        return "<html>" +
                "<head><title>Image Viewer</title></head>" +
                "<body>" +
                "<h1>Value point Systems Demo - Openshift CI CD</h1>" +
                "<h2>App modernization</h2>" +
                "<img src='" + imagePath + "' alt='Image' width='500'/>" +
                "</body>" +
                "</html>";
    }
}
