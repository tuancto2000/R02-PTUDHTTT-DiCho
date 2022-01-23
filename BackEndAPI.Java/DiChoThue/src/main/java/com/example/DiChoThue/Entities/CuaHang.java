package com.example.DiChoThue.Entities;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "CUA_HANG")
public class CuaHang {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int ma_cua_hang;
    private int ma_nguoi_dung;
    private String sdt;
    private String email;
    private String ten_cua_hang;
    private String ma_dia_chi;
}
