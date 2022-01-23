package com.example.DiChoThue.Repository;

import com.example.DiChoThue.Entities.HinhAnh;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface HinhAnhRepository extends JpaRepository<HinhAnh, Integer> {

}
