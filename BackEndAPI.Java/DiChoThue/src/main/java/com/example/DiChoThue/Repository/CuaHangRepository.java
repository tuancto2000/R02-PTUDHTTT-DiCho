package com.example.DiChoThue.Repository;

import com.example.DiChoThue.Entities.CuaHang;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface CuaHangRepository extends JpaRepository<CuaHang, Integer> {

}
