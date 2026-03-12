<script setup lang="ts">



const items = [
    {
        title: 'Dashboard',
        url: '/',
        icon: 'warehouse',
    },
    {
        title: 'Members',
        url: '/members',
        icon: 'users'
    },
    
    {
        title: 'Prets',
        url: '/borrows',
        icon: 'file-output'
    },
    {
        title: 'Restitutions',
        url: '/restitutions',
        icon: 'file-input'
    },
    {
        title: 'Document Managment',
        url: '/documents',
        icon: 'book-open'
    },
    {
        title: 'Holds',
        url: '/holds',
        icon: 'timer'
    },
    {
        title: 'Borrowed Documents',
        url: '/borrowed',
        icon: 'book-up'
    },
    {
        title: 'Reminders',
        url: '/reminders',
        icon: 'bell-ring'
    },
    {
        title: 'Reserved Docs',
        url: '/reserved_docs',
        icon: 'clipboard-clock'
    },
    {
        title: 'Categories',
        url: '/categories',
        icon: 'align-justify'
    }
]

</script>

<template>
    <div class="flex min-h-full flex-col items-start bg-base-200 is-drawer-close:w-16 is-drawer-open:w-64">
        <!-- Sidebar content here -->
        <ul class="menu w-full grow">
            <!-- List item -->
            <li v-for="item in items" class="w-full">
                <NuxtLink :to="item.url"  active-class="menu-active"
                        class=" sidebar-link w-full is-drawer-close:tooltip-right"
                        data-tip="Homepage">
                        <!-- Home icon -->
                        <Icon :name="`lucide:${item.icon}`" class="my-1.5 inline-block size-5" />

                        <p class="is-drawer-close:hidden">{{ item.title }}</p>

                </NuxtLink>
            </li>

        </ul>
    </div>
</template>