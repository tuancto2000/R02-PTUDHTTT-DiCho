package com.example.DiChoThue.Repository;

import com.example.DiChoThue.Entities.ChiTietGioHang;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ChiTIetGioHangRepository extends JpaRepository<ChiTietGioHang, Integer> {

}
