'use client'

import { Pagination } from 'flowbite-react'
import React from 'react'

type Props = {
    currentPage: number
    pageCount: number
    pageChanged: (page: number) => void
}

export default function AppPagination({currentPage, pageCount, pageChanged} : Props) {
    return (
    <div>
        <Pagination 
            currentPage={currentPage}
            onPageChange={e => pageChanged(e)}
            totalPages={pageCount}
            showIcons
            layout="pagination"
            className='text-blue-500 mb-5 text-sm'
        />
    </div>
  )
}
