package com.example.DiChoThue.Entities;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "CUA_HANG")
public class CuaHang {
    @Id
    private int MA_CUA_HANG;
    private int MA_NGUOI_DUNG;
    private String SDT;
    private String EMAIL;
    private String TEN_CUA_HANG;
    private String DIA_CHI;
}
