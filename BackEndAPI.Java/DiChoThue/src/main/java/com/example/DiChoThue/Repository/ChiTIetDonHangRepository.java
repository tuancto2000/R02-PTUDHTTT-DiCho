package com.example.DiChoThue.Repository;

import com.example.DiChoThue.Entities.ChiTietDonHang;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ChiTIetDonHangRepository extends JpaRepository<ChiTietDonHang, Integer> {

}
