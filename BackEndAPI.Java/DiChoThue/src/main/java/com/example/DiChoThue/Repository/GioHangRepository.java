package com.example.DiChoThue.Repository;

import com.example.DiChoThue.Entities.GioHang;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface GioHangRepository extends JpaRepository<GioHang, Integer> {

}
