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
@Table(name = "HINH_ANH")
public class HinhAnh {
    @Id
    private int MA_HINH_ANH;
    private int MA_SP;
    private String NGUON_HINH_ANH;
    private Boolean MAC_DINH;
}
