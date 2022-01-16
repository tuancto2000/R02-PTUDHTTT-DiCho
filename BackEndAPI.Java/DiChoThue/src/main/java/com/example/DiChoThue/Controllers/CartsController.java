package com.example.DiChoThue.Controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.persistence.EntityManager;

@RestController
@RequestMapping("/api/carts")
public class CartsController {
    @Autowired
    private EntityManager entityManager;

    
}
