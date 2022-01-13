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
@Table(name = "SAN_PHAM")
public class SanPham {
    @Id
    private int MA_SP;
    private int MA_CUA_HANG;
    private int MA_DM;
    private String TEN_SP;
    private int GIA_SP;
    private int SO_LUONG_CON_LAI;
    private String MO_TA;
}
