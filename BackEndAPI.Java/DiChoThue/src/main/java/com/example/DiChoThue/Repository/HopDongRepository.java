package com.example.DiChoThue.Repository;

import com.example.DiChoThue.Entities.HopDong;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface HopDongRepository extends JpaRepository<HopDong, Integer> {

}
