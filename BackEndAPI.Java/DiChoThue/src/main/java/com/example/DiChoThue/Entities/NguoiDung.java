package com.example.DiChoThue.Entities;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;
import java.util.Date;

@Data
@AllArgsConstructor
@NoArgsConstructor
@Entity
@Table(name = "NGUOI_DUNG")
public class NguoiDung {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int ma_nguoi_dung;
    private String ten_nguoi_dung;
    private Date ngay_sinh;
    private String sdt;
    private String email;
    private String vai_tro;
    private Boolean KichHoat;
    private int ma_dia_chi;
}
