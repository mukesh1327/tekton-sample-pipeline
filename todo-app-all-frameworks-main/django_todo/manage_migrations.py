# manage_migrations.py
import os
import sys

def main():
    # Set the Django settings module to your project's settings module
    os.environ.setdefault('DJANGO_SETTINGS_MODULE', 'django_todo.settings')

    try:
        # Import Django's management module
        from django.core.management import execute_from_command_line

        # Run migrations
        execute_from_command_line(['manage.py', 'makemigrations'])
        execute_from_command_line(['manage.py', 'migrate'])

    except ImportError as e:
        print(f"Error importing Django: {e}")
        sys.exit(1)

if __name__ == "__main__":
    main()