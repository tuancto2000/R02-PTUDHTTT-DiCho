package com.example.DiChoThue.Controllers;

import com.example.DiChoThue.Entities.DanhMuc;
import com.example.DiChoThue.Repository.DanhMucRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/api/categories")
public class CategoriesController {
    @Autowired
    DanhMucRepository danhMucRepository;

    @GetMapping
    public List<DanhMuc> getAllCategories() {
        return danhMucRepository.findAll();
    }
}
