package com.example.DiChoThue.Repository;

import com.example.DiChoThue.Entities.GoiSanPham;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface GoiSanPhamRepository extends JpaRepository<GoiSanPham, Integer> {

}
