package com.example.DiChoThue.Repository;

import com.example.DiChoThue.Entities.DonHang;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.Date;

@Repository
public interface DonHangRepository extends JpaRepository<DonHang, Integer> {
}
