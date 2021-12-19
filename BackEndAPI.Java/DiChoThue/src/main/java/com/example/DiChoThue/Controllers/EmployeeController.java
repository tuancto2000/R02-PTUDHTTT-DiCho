package com.example.DiChoThue.Controllers;

import com.example.DiChoThue.Models.Employee;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.concurrent.CopyOnWriteArrayList;

@RestController
@RequestMapping("/api")
public class EmployeeController {
    private List<Employee> employeeList = new CopyOnWriteArrayList<>();

    @PostMapping("/employee")
    public ResponseEntity addEmployee(@RequestBody Employee employee) {

        employee.setPhone("0" + employee.getPhone());
        employeeList.add(employee);

        return ResponseEntity.ok().body(employee);
    }

    @GetMapping("/employee")
    public List<Employee> getlistEmployee() {
        return employeeList;
    }

    @GetMapping("/employee/{number}")
    public List<Employee> listEmployee(@PathVariable(name = "number") Integer number) {
        if (number == null || number > employeeList.size()) {
            return employeeList;
        }
        return employeeList.subList(0, number);
    }
}
