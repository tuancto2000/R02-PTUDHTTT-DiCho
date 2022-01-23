package com.example.DiChoThue.Repository;

import com.example.DiChoThue.Entities.DonHang;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface DonHangRepository extends JpaRepository<DonHang, Integer> {

}
