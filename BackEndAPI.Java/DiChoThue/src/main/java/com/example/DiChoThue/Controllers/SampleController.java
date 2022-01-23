package com.example.DiChoThue.Controllers;

import com.example.DiChoThue.Entities.NguoiDung;
import com.example.DiChoThue.Exception.ResourceNotFoundException;
import com.example.DiChoThue.Repository.NguoiDungRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@RestController
@RequestMapping("/api/sample")
public class SampleController {
    @Autowired
    NguoiDungRepository nguoiDungRepository;

    @GetMapping("/users")
    public List<NguoiDung> getAllUsers() {
        return nguoiDungRepository.findAll();
    }

    @PostMapping("/user")
    public NguoiDung createUser(@Valid @RequestBody NguoiDung nguoiDung) {
        return nguoiDungRepository.save(nguoiDung);
    }

    @GetMapping("/user/{id}")
    public ResponseEntity<NguoiDung> getUserById(@PathVariable(value = "id") Integer userId)
            throws ResourceNotFoundException {
        NguoiDung nguoiDung = nguoiDungRepository.findById(userId)
                .orElseThrow(() -> new ResourceNotFoundException("Employee not found for this id :: " + userId));
        return ResponseEntity.ok().body(nguoiDung);
    }

    @PutMapping("/user/{id}")
    public ResponseEntity<NguoiDung> updateUser(@PathVariable(value = "id") Integer userId,
                                                @Valid @RequestBody NguoiDung nguoiDungDetail) throws ResourceNotFoundException {
        NguoiDung nguoiDung = nguoiDungRepository.findById(userId)
                .orElseThrow(() -> new ResourceNotFoundException("Employee not found for this id :: " + userId));

        nguoiDung.setTen_nguoi_dung(nguoiDungDetail.getTen_nguoi_dung());
        nguoiDung.setEmail(nguoiDungDetail.getEmail());

        final NguoiDung updatedUser = nguoiDungRepository.save(nguoiDung);
        return ResponseEntity.ok(updatedUser);
    }

    @DeleteMapping("/user/{id}")
    public Map<String, Boolean> deleteUser(@PathVariable(value = "id") Integer userId)
            throws ResourceNotFoundException {
        NguoiDung nguoiDung = nguoiDungRepository.findById(userId)
                .orElseThrow(() -> new ResourceNotFoundException("Employee not found for this id :: " + userId));

        nguoiDungRepository.delete(nguoiDung);
        Map<String, Boolean> response = new HashMap<>();
        response.put("deleted", Boolean.TRUE);
        return response;
    }

    @GetMapping("/test")
    @ResponseBody
    public String getFoos(@RequestParam String id, @RequestParam(value = "l", required = false) String l) {
        if (l == null) {
            return "ID: " + id;
        }
        return "ID: " + id + l;
    }
}
