package com.zagaopc.springboottodo.repository;

import org.springframework.data.jpa.repository.JpaRepository;

// import org.springframework.data.repository.CrudRepository;
// import org.springframework.stereotype.Repository;

import com.zagaopc.springboottodo.model.entity.Tasks;

// @Repository
public interface TasksRepository extends JpaRepository<Tasks, Integer> {
    boolean existsByName(String name);
}
