package com.example.DiChoThue.Controllers;

import com.example.DiChoThue.Entities.DanhMuc;
import com.example.DiChoThue.Entities.HinhAnh;
import com.example.DiChoThue.Entities.SanPham;
import com.example.DiChoThue.Exception.ResourceNotFoundException;
import com.example.DiChoThue.Models.CreateProductModel;
import com.example.DiChoThue.Models.GetProductByIdModel;
import com.example.DiChoThue.Models.SanPhamModel;
import com.example.DiChoThue.Models.UpdateProductModel;
import com.example.DiChoThue.Repository.HinhAnhRepository;
import com.example.DiChoThue.Repository.SanPhamRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.persistence.EntityManager;
import javax.persistence.Query;
import javax.validation.Valid;
import java.util.List;

import static java.util.stream.Collectors.toSet;

@RestController
@RequestMapping("/api/products")
public class ProductsController {
    @Autowired
    SanPhamRepository sanPhamRepository;

    @Autowired
    HinhAnhRepository hinhAnhRepository;

    @Autowired
    private EntityManager entityManager;

    @GetMapping("/store/{storeId}")
    public ResponseEntity<List<SanPhamModel>> getAllProductsOfStore(@PathVariable(value = "storeId") Integer storeId)
            throws ResourceNotFoundException {
        String sql = "Select new " + SanPhamModel.class.getName()
                + "(sp.ma_sp, dm.ma_dm, dm.ten_dm, sp.ten_sp, sp.gia_sp, sp.so_luong_con_lai, sp.mo_ta, sp.soluotdanhgia, sp.trungbinhsao) "
                + " from " + SanPham.class.getName() + " sp join " + DanhMuc.class.getName()
                + " dm on sp.ma_dm = dm.ma_dm where sp.ma_cua_hang = " + storeId;
        Query query = entityManager.createQuery(sql, SanPhamModel.class);
        return ResponseEntity.ok().body(query.getResultList());
    }

    @GetMapping("/{productId}")
    public ResponseEntity<GetProductByIdModel> getProductById(@PathVariable(value = "productId") Integer productId)
            throws ResourceNotFoundException {
        String sql = "Select new " + SanPhamModel.class.getName()
                + "(sp.ma_sp, dm.ma_dm, dm.ten_dm, sp.ten_sp, sp.gia_sp, sp.so_luong_con_lai, sp.mo_ta, sp.soluotdanhgia, sp.trungbinhsao) "
                + " from " + SanPham.class.getName() + " sp join " + DanhMuc.class.getName()
                + " dm on sp.ma_dm = dm.ma_dm where sp.ma_sp = " + productId;
        SanPhamModel sanPhamModel = entityManager.createQuery(sql, SanPhamModel.class).getSingleResult();
        List<HinhAnh> listHinhAnh = hinhAnhRepository.getImByProductId(sanPhamModel.getMa_sp());

        GetProductByIdModel product = new GetProductByIdModel(sanPhamModel, listHinhAnh);
        return ResponseEntity.ok().body(product);
    }

    @PostMapping
    public ResponseEntity<Integer> createProduct(@Valid @RequestBody CreateProductModel product) {
        SanPham sanPham = new SanPham();

        sanPham.setMa_cua_hang(product.getMa_cua_hang());
        sanPham.setMa_dm(product.getMa_dm());
        sanPham.setTen_sp(product.getTen_sp());
        sanPham.setGia_sp(product.getGia_sp());
        sanPham.setSo_luong_con_lai(product.getSo_luong_con_lai());
        sanPham.setMo_ta(product.getMo_ta());

        int productId = sanPhamRepository.save(sanPham).getMa_sp();

        for(HinhAnh ha : product.getHinh_anh()){
            ha.setMa_sp(productId);
            hinhAnhRepository.save(ha);
        }

        return ResponseEntity.ok(productId);
    }

    @PutMapping("/{productId}")
    public ResponseEntity<Boolean> updateProduct(@PathVariable(value = "productId") Integer productId,
                                                 @Valid @RequestBody UpdateProductModel sanPhamDetail)
            throws ResourceNotFoundException {
        SanPham sanPham = sanPhamRepository.findById(productId)
                .orElseThrow(() -> new ResourceNotFoundException("Product not found for this id :: " + productId));

        sanPham.setTen_sp(sanPhamDetail.getTen_sp());
        sanPham.setMo_ta(sanPhamDetail.getMo_ta());
        sanPham.setGia_sp(sanPhamDetail.getGia_sp());
        sanPham.setSo_luong_con_lai(sanPham.getSo_luong_con_lai() + sanPhamDetail.getSo_luong_con_lai());
        sanPham.setMa_dm(sanPhamDetail.getMa_dm());

        sanPhamRepository.save(sanPham);
        List<HinhAnh> listHinhAnhNew = sanPhamDetail.getHinh_anh();

        if(listHinhAnhNew != null){
            List<HinhAnh> listHinhAnhOld = hinhAnhRepository.getImByProductId(productId);

            for(HinhAnh ha : listHinhAnhOld){
                if(!listHinhAnhNew.contains(ha)){
                    hinhAnhRepository.delete(ha);
                }
            }

            for (HinhAnh ha: listHinhAnhNew) {
                if(ha.getMa_hinh_anh() == 0){
                    hinhAnhRepository.save(ha);
                }
            }
        }

        return ResponseEntity.ok(Boolean.TRUE);
    }

    @DeleteMapping("/{productId}")
    public ResponseEntity<Boolean> deleteProduct(@PathVariable(value = "productId") Integer productId)
            throws ResourceNotFoundException {
        SanPham sanPham = sanPhamRepository.findById(productId)
                .orElseThrow(() -> new ResourceNotFoundException("Product not found for this id :: " + productId));

        sanPhamRepository.changeState(productId);

        return ResponseEntity.ok(Boolean.TRUE);
    }

    @GetMapping("/test")
    @ResponseBody
    public String getFoos(@RequestParam String id,@RequestParam(value = "l", required=false) String l ) {
        if(l==null){
            return "ID: " + id;
        }
        return "ID: " + id + l;
    }
}
