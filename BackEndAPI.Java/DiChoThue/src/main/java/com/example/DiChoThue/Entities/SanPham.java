package com.example.DiChoThue.Entities;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "SAN_PHAM")
public class SanPham {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int ma_sp;
    private int ma_cua_hang;
    private int ma_dm;
    private String ten_sp;
    private int gia_sp;
    private int so_luong_con_lai;
    private String mo_ta;
}
