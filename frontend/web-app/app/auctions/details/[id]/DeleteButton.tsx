'use client'

import { deleteAuction } from '@/app/actions/auctionActions'
import { error } from 'console'
import { Button } from 'flowbite-react'
import Link from 'next/link'
import { useRouter } from 'next/navigation'
import React, { useState } from 'react'
import toast from 'react-hot-toast'

type Props = {
    id: string
}

export default function DeleteButton({ id }: Props) {
    const [loading, setLoading] = useState(false);
    const router = useRouter();

    function doDelete() {
        setLoading(true);
        deleteAuction(id)
            .then((res) => {
                if (res.error) throw res.error;
                router.push(`/`);
            }).catch(error => {
                toast.error(error.status + ' ' + error.message)
            }).finally(() => setLoading(false))
    }

    return (
        <Button isProcessing={loading} color='failure' onClick={doDelete}>
            Delete Auction
        </Button>
    )
}
